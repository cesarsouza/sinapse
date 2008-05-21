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

using AForge.Math;
using AForge.Math.LinearAlgebra.Decompositions;
using AForge.Statistics;


namespace AForge.Statistics.SampleAnalysis
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

        // public enum AnalysisMethod { Covariance, Correlation, Singular };

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

        //---------------------------------------------


        #region Constructor
        /// <summary>Constructs the Principal Component Analysis.</summary>
        /// <param name="data"></param>
        public PrincipalComponentAnalysis(Matrix data, bool center, bool standardize)
        {
            this.m_sourceMatrix = data;
            this.m_standardize = standardize;
            this.m_center = center;
        }

        public PrincipalComponentAnalysis(Matrix data)
            : this(data,true,true)
        {
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// Returns the original supplied data to be analyzed.
        /// </summary>
        public Matrix SourceMatrix
        {
            get { return this.m_sourceMatrix; }
        }

        public Matrix ResultMatrix
        {
            get { return this.m_resultMatrix; }
        }

        /// <summary>Gets the matrix whose columns contain the principal components. Also known as the EigenVectors or FeatureVectors matrix</summary>
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

        /// <summary>The cumulative distribution of the components proportion role.</summary>
        public Vector CumulativeProportions
        {
            get { return m_cumulativeProportions; }
        }

        /// <summary>Provides access to the Singular Values stored during the analysis.</summary>
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
            get { return this.m_center; }
            set { this.m_center = value; }
        }

        /// <summary>Gets or sets a value determining if the source data will be divided by its Standard Deviation during the analysis.</summary>
        public bool Standardize
        {
            get { return this.m_standardize; }
            set { this.m_standardize = value; }
        }

        public Vector StandardDeviations
        {
            get { return this.m_stdDev; }
        }

        public Vector Means
        {
            get { return this.m_mean; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods

        /// <summary>Computes the Principal Component Analysis algorithm.</summary>
        public void Compute()
        {

            Matrix matrix = this.m_sourceMatrix.Clone();

            this.m_mean = Tools.Mean(matrix);
            this.m_stdDev = Tools.StandardDeviation(matrix, m_mean);

            if (this.m_center)
            {
                Statistics.Tools.Center(matrix, m_mean);
            }
            if (this.m_standardize)
            {
                Statistics.Tools.Standardize(matrix, m_stdDev);
            }


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

            // Calculate proportions and cumulative proportions
            this.m_proportions = Vector.Pow(this.m_singularValues, 2);
            this.m_proportions = this.m_proportions * (1.0 / this.m_proportions.Sum);

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


            // Calculate the orthogonal projected data matrix (using all available component)
            this.m_resultMatrix = this.m_sourceMatrix * this.m_eigenVectors;
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        public Matrix Apply(Matrix matrix)
        {
            return matrix * this.m_eigenVectors;
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        /// <param name="components">The number of components to consider.</param>
        public Matrix Apply(Matrix matrix, int components)
        {
            return matrix * this.m_eigenVectors.Submatrix(0, this.m_eigenVectors.Columns-1, 0, components-1);
        }

        /// <summary>Projects a given matrix into a orthogonal space.</summary>
        /// <param name="matrix">The matrix to be projected.</param>
        /// <param name="threshold">The percentage of information that should be projected.</param>
        public Matrix Apply(Matrix matrix, float threshold)
        {
            return Apply(matrix, GetNumberOfComponents(threshold));
        }

        public Matrix Revert(Matrix data, int components)
        {
            Matrix original;

            if (components == m_eigenValues.Length)
                original = data * m_eigenVectors.Transpose();
            else
                original = data * selectVectors(components).Inverse();

            for (int j = 0; j < original.Columns; j++)
            {
                for (int i = 0; i < original.Rows; i++)
                {
                    if (m_standardize)
                        original[i][j] *= this.m_stdDev[j];
                    if (m_center)
                        original[i][j] += m_mean[j];
                }
            }
            return original;
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
        #endregion

    }

    //---------------------------------------------


    public class PrincipalComponent
    {

        private int m_index;
        private PrincipalComponentAnalysis m_analysis;
        private bool m_selected;

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
        public int Index
        {
            get { return this.m_index; }
        }

        public bool Selected
        {
            get { return this.m_selected; }
            set { this.m_selected = value; }
        }

        public PrincipalComponentAnalysis Analysis
        {
            get { return this.m_analysis; }
        }

        public double Proportion
        {
            get { return this.m_analysis.Proportions[m_index]; }
        }

        public double CumulativeProportion
        {
            get { return this.m_analysis.CumulativeProportions[m_index]; }
        }

        public double SingularValue
        {
            get {return this.m_analysis.SingularValues[m_index]; }
        }

        public double EigenValue
        {
            get { return this.m_analysis.EigenValues[m_index]; }
        }

        public Vector Value
        {
            get { return (Vector)this.m_analysis.ComponentMatrix.GetColumn(m_index); }
        }
        #endregion

    }

    public class PrincipalComponentCollection : ReadOnlyCollection<PrincipalComponent>
    {
        internal PrincipalComponentCollection(PrincipalComponent[] components)
            : base(components)
        {
        }

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
    }
}
