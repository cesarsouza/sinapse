/***************************************************************************
 *                                                                         *
 *  Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com>  *
 *                                                                         *
 *  Please note that this code is not part of the original AForge.NET      *
 *  library. This extension was created to support new features needed by  *
 *  Sinapse, a neural networking tool software. Unless otherwise advised,  *
 *  this code relies under protection of the GNU General Public License v3 *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

using AForge.Mathematics;
using AForge.Mathematics.LinearAlgebra.Decompositions;
using AForge.Statistics;


namespace AForge.Statistics.DataAnalysis
{

    /// <summary>
    ///   Principal component analysis (PCA) is a technique used to reduce
    ///   multidimensional data sets to lower dimensions for analysis.
    /// </summary>
    /// <remarks>
    ///   Principal Components Analysis or the Karhunen-Loeve expansion is a
    ///   classical method for dimensionality reduction or exploratory data
    ///   analysis.
    ///  
    ///   Mathematically, PCA is a process that decomposes the covariance matrix of a matrix
    ///   into two parts: eigenvalues and column eigenvectors, whereas Singular Value Decomposition
    ///   (SVD) decomposes a matrix per se into three parts: singular values, column eigenvectors,
    ///   and row eigenvectors. The relationships between PCA and SVD lie in that the eigenvalues 
    ///   are the square of the singular values and the column vectors are the same for both.   
    ///</remarks>
    public sealed class PrincipalComponentAnalysis
    {

        /// <summary>
        ///   Determines the method to be used in a Principal Component Analysis.
        /// </summary>
        public enum AnalysisMethod
        {
            /// <summary>
            ///  By choosing Covariance, the method will be run on the Covariance Matrix of the given data
            /// </summary>
            Covariance, 
            
            /// <summary>
            ///  By choosing Correlation, the method will be run on the Correlation Matrix of the given data.
            /// </summary>
            Correlation, 
            
            /// <summary>
            ///   By choosing SingularDefault, the method will be held directly on the mean-subtracted data.
            /// </summary>
            SingularDefault,
            
            /// <summary>
            ///   By choosing SingularStandard, the method will be run directly on the mean-subtracted,
            ///    standardized data (also known as Z-Scores, the core of the data). This method is required
            ///    when different columns from the given data have different measuring units.
            /// </summary>
            SingularStandard
        
        };

        private Matrix m_sourceMatrix;
        private Matrix m_resultMatrix;

        private Vector m_mean;
        private Vector m_stdDev;
                                                              
        private Vector m_singularValues;
        private Vector m_eigenValues;
        private Vector m_proportions;
        private Matrix m_eigenVectors;
        private Vector m_cumulativeProportions;
        private PrincipalComponentCollection m_componentCollection;

        private bool m_center;
        private bool m_standardize;
        private AnalysisMethod m_method;

        //---------------------------------------------


        #region Constructor
        /// <summary>Constructs the Principal Component Analysis.</summary>
        /// <param name="data">The source data to perform analysis. A copy of this object will be used on the process.</param>
        /// <param name="method">The analysis method to perform.</param>
        public PrincipalComponentAnalysis(Matrix data, AnalysisMethod method)
        {
            this.m_sourceMatrix = data;

            this.Method = method;

            this.m_center = true;
            // this.m_standardize will be set automatically by this.Method set property.            
        }

        /// <summary>Constructs the Principal Component Analysis. By default, the SingularValues method will be used.</summary>
        /// <param name="data">The source data to perform analysis. A copy of this object will be used on the process.</param>
        public PrincipalComponentAnalysis(Matrix data)
            : this(data, AnalysisMethod.SingularDefault)
        {
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>Returns the original supplied data to be analyzed.</summary>
        public Matrix SourceMatrix
        {
            get { return this.m_sourceMatrix; }
        }

        /// <summary>Gets the resulting projection of the source data given on the creation of the analysis into an orthogonal space.</summary>
        public Matrix ResultMatrix
        {
            get { return this.m_resultMatrix; }
        }

        /// <summary>Gets the matrix whose columns contain the principal components. Also known as the EigenVectors or FeatureVectors matrix.</summary>
        public Matrix ComponentMatrix
        {
            get { return this.m_eigenVectors; }
        }

        /// <summary>Gets the Principal Components in a object-oriented fashion.</summary>
        public PrincipalComponentCollection Components
        {
            get { return m_componentCollection; }
        }

        /// <summary>The respective role each component plays in the data set.</summary>
        public Vector Proportions
        {
            get { return m_proportions; }
        }

        /// <summary>The cumulative distribution of the components proportion role. Also known
        /// as the cumulative energy of the principal components.</summary>
        public Vector CumulativeProportions
        {
            get { return m_cumulativeProportions; }
        }

        /// <summary>Provides access to the Singular Values stored during the analysis.
        /// If a covariance method is choosen, then it will contain an empty vector.</summary>
        public Vector SingularValues
        {
            get { return m_singularValues; }
        }

        /// <summary>Provides access to the Eigen Values stored during the analysis.</summary>
        public Vector EigenValues
        {
            get { return m_eigenValues; }
        }

        /// <summary>Gets or sets a value determining if the source data will have it's mean subtracted during the analysis.</summary>
        public bool Center
        {
            get { return m_center; }
        }

        /// <summary>Gets or sets a value determining if the source data will be divided by its Standard Deviation during the analysis.</summary>
        /// <remarks>This property can only be changed if the SingularValue Analysis Method is being used.</remarks>
        public bool Standardize
        {
            get { return this.m_standardize; }
        }

        /// <summary>Gets the standard deviations of the original data given at method construction.
        /// It is particulary useful for reconstructing aldready projected data.</summary>
        public Vector StandardDeviations
        {
            get { return this.m_stdDev; }
        }

        /// <summary>Gets the mean of the original data given at method construction.
        /// It is particulary useful for reconstructing already projected data.</summary>
        public Vector Means
        {
            get { return this.m_mean; }
        }

        /// <summary>Gets or sets the method used by this analysis.</summary>
        public AnalysisMethod Method
        {
            get { return this.m_method; }
            set
            {
                this.m_method = value;

                this.m_standardize =
                    (m_method == AnalysisMethod.Correlation ||
                     m_method == AnalysisMethod.SingularStandard);
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods

        /// <summary>Computes the Principal Component Analysis algorithm.</summary>
        public void Compute()
        {
            // Create a copy of the original matrix to work upon
            Matrix matrix = this.m_sourceMatrix.Clone();

            // Calculate common measures to speedup other calculations
            this.m_mean = Tools.Mean(matrix);
            this.m_stdDev = Tools.StandardDeviation(matrix, m_mean);


            // Normalize the data
            if (this.Center)
                Statistics.Tools.Center(matrix, m_mean);
            if (this.Standardize)
                Statistics.Tools.Standardize(matrix, m_stdDev);


            if (Method == AnalysisMethod.SingularDefault || Method == AnalysisMethod.SingularStandard)
            {
                // Perform the Singular Value Decomposition (SVD) of the standardized matrix
                SingularValueDecomposition singularDecomposition = new SingularValueDecomposition(matrix);
                this.m_singularValues = new Vector(singularDecomposition.Diagonal);


                // Eigen values are the square of the singular values
                this.m_eigenValues = Vector.Pow(this.m_singularValues, 2);


                /* The principal components of 'sourceMatrix' are the eigenvectors of Cov(sourceMatrix). If we
                 * calculate the SVD of 'matrix' (which is sourceMatrix standardized), the columns of matrix V
                 * (right side of SVD) are the principal components of sourceMatrix.  */

                // The right singular vectors contains the principal components of the data matrix
                this.m_eigenVectors = singularDecomposition.RightSingularVectors;

                // The left singulare vectors contains the scores of the principal components
            }
            else
            {
                // Generate covariance matrix
                //  (if data has already been standardized, this will be the correlation matrix)
                Matrix covarianceMatrix = Statistics.Tools.Covariance(matrix, m_mean);

                // Perform the Eigen Value Decomposition (EVD) of the covariance (or correlation) matrix
                EigenValueDecomposition eigenDecomposition = new EigenValueDecomposition(covarianceMatrix);
                this.m_eigenValues = eigenDecomposition.RealEigenValues;
                this.m_eigenVectors = eigenDecomposition.EigenVectors;

                // Now we have to sort EigenValues and EigenVectors in descending order of Eigen Values,
                //  from left to right. (Higher eigenvalues <----> Lower eigenvalues).

                // EigenValueDecomposition already returned its vectors and values in reverse
                //  order, so we just have to reverse our arrays.
                    this.m_eigenValues.Reverse();
                    this.m_eigenVectors.ReverseColumns();
                
                // Because Sigular Values have not been computed, create a empty vector
                //  to avoid Null reference exceptions.
                this.m_singularValues = new Vector(m_eigenValues.Length);                
            }

            

            // Calculate proportions and cumulative proportions
            this.m_proportions = this.m_eigenValues * (1.0 / this.m_eigenValues.Sum);

            this.m_cumulativeProportions = new Vector(this.m_sourceMatrix.Columns);
            this.m_cumulativeProportions[0] = this.m_proportions[0];
            for (int i = 1; i < this.m_cumulativeProportions.Length; i++)
            {
                this.m_cumulativeProportions[i] = this.m_cumulativeProportions[i - 1] + this.m_proportions[i];
            }


            // Creates the object-oriented structure to hold the principal components
            PrincipalComponent[] components = new PrincipalComponent[m_singularValues.Length];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = new PrincipalComponent(this, i);
            }
            this.m_componentCollection = new PrincipalComponentCollection(components);


            // Calculate the orthogonal projected data matrix (using all available components)
            this.m_resultMatrix = matrix * this.m_eigenVectors;
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        public Matrix Transform(Matrix matrix, bool standardizeFirst)
        {
            return Statistics.Tools.ZScores(matrix) * this.m_eigenVectors;
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        public Matrix Transform(Matrix matrix)
        {
            return this.Transform(matrix, true);
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        /// <param name="components">The number of components to consider.</param>
        public Matrix Transform(Matrix matrix, int components)
        {
            return this.Transform(this.m_eigenVectors.Submatrix(0, this.m_eigenVectors.Columns-1, 0, components-1));
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        /// <param name="threshold">The percentage of information that should be projected.</param>
        public Matrix Transform(Matrix matrix, float threshold)
        {
            return this.Transform(matrix, GetNumberOfComponents(threshold));
        }

        /// <summary>
        ///   Reverts a set of projected data into it's original form. Complete reverse
        ///   transformation is only possible if all components are used, and, if the
        ///   data has been standardized, the original standard deviation and means of
        ///   the original matrix are known.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public Matrix Revert(Matrix data, int components)
        {
            Matrix original;

            if (components == m_eigenValues.Length)
                original = data * m_eigenVectors.Transpose();
            else
                original = data * selectVectors(components).Inverse();

            return original;
        }

        /// <summary>
        ///   Reverts a set of projected data into it's original form. Complete reverse
        ///   transformation is only possible if all components are used, and, if the
        ///   data has been standardized, the original standard deviation and means of
        ///   the original matrix are known.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public Matrix Revert(Matrix data, Vector mean, Vector stdDev, int components)
        {
            Matrix projection = this.Revert(data, components);
                      
            for (int j = 0; j < projection.Columns; j++)
            {
                for (int i = 0; i < projection.Rows; i++)
                {
                    projection[i][j] *= stdDev[j];
                    projection[i][j] += mean[j];
                }
            }

            return projection;
        }

        /// <summary>
        /// Returns the minimal number of principal components required to represent a
        /// given percentile of the data.
        /// </summary>
        /// <param name="threshold">The percentile of the data requiring representation.</param>
        /// <returns>The minimal number of components required.</returns>
        public int GetNumberOfComponents(float threshold)
        {
            if (threshold < 0 || threshold > 1.0)
                throw new ArgumentException("Threshold should be a value between 0 and 1","threshold");
            
            for (int i = 0; i < this.m_cumulativeProportions.Length; i++)
            {
                if (this.m_cumulativeProportions[i] > threshold)
                    return i;
            }

            return this.m_cumulativeProportions.Length;
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private Matrix selectVectors(int components)
        {
            return this.m_eigenVectors.Submatrix(0, this.m_eigenVectors.Columns - 1, 0, components - 1);
        }
/*
        private Matrix selectVectors()
        {
            return selectVectors(m_componentCollection.SelectedComponents);
        }
 */ 
        #endregion

    }

    //---------------------------------------------


    /// <summary>
    ///   Represents a Principal Component found in the Principal Component Analysis.
    ///   This class cannot be instantiated.
    /// </summary>
    public class PrincipalComponent
    {

        private int m_index;
        private PrincipalComponentAnalysis m_analysis;
     //   private bool m_selected;

        //---------------------------------------------

        #region Constructor
        internal PrincipalComponent(PrincipalComponentAnalysis analysis, int index)
        {
            this.m_index = index;
            this.m_analysis = analysis;
        }
        #endregion

        //---------------------------------------------

        #region Properties
        /// <summary>Gets the Index of this component on the original analysis principal component collection.</summary>
        public int Index
        {
            get { return this.m_index; }
        }
/*
        public bool Selected
        {
            get { return this.m_selected; }
            set { this.m_selected = value; }
        }
*/
        /// <summary>Returns a reference to the parent analysis object.</summary>
        public PrincipalComponentAnalysis Analysis
        {
            get { return this.m_analysis; }
        }
        
        /// <summary>Gets the proportion of data this component represents.</summary>
        public double Proportion
        {
            get { return this.m_analysis.Proportions[m_index]; }
        }

        /// <summary>Gets the cumulative proportion of data this component represents.</summary>
        public double CumulativeProportion
        {
            get { return this.m_analysis.CumulativeProportions[m_index]; }
        }

        /// <summary>If available, gets the Singular Value of this component found during the Analysis.</summary>
        public double SingularValue
        {
            get {return this.m_analysis.SingularValues[m_index]; }
        }

        /// <summary>Gets the Eigen Value of this component found during the analysis.</summary>
        public double EigenValue
        {
            get { return this.m_analysis.EigenValues[m_index]; }
        }

        /// <summary>Gets the Eigenvector of this component.</summary>
        public Vector EigenVector
        {
            get { return (Vector)this.m_analysis.ComponentMatrix.GetColumn(m_index); }
        }
        #endregion

    }

    /// <summary>
    ///   Represents a Collection of Principal Components found in the Principal Component Analysis.
    ///   This class cannot be instantiated.
    /// </summary>
    public class PrincipalComponentCollection : ReadOnlyCollection<PrincipalComponent>
    {
        internal PrincipalComponentCollection(PrincipalComponent[] components)
            : base(components)
        {
        }
/*
        public int SelectedComponents
        {
            get
            {
                int count = 0;
                foreach (PrincipalComponent pc in this)
                {
                    count++;
                }
                return count;
            }
        }
 */ 
    }
}
