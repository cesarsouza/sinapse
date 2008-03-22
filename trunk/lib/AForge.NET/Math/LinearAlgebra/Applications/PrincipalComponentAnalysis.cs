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
using System.Text;

using AForge.Math.LinearAlgebra;
using AForge.Math.Statistic;


namespace AForge.Math.LinearAlgebra.Applications
{


    /// <summary>
    /// Principal component analysis (PCA) is a technique used to reduce
    /// multidimensional data sets to lower dimensions for analysis.
    /// </summary>
    /// <remarks>
    /// Principal Components Analysis or the Karhunen-Loeve expansion is a
    /// classical method for dimensionality reduction or exploratory data
    /// analysis.  One reference among many is: F. Murtagh and A. Heck,
    /// Multivariate Data Analysis, Kluwer Academic, Dordrecht, 1987. 
    ///     
    ///                          Based on work by F. Murtagh, 6 June 1989
    ///</remarks>
    public class PrincipalComponentAnalysis
    {

        public enum AnalysisType { Covariance, Correlation }

        private SampleMatrix m_originalMatrix;
        private Vector m_eigenValues;
        private Matrix m_eigenVectors;

        private Matrix m_featureVector;

        private Vector m_matrixMean;
        private Vector m_matrixStdDev;

        private Vector m_scores;


        //---------------------------------------------


        #region Constructor
        public PrincipalComponentAnalysis(Matrix matrix, DataModel model)
            : this(new SampleMatrix(matrix, model))
        {
        }

        public PrincipalComponentAnalysis(SampleMatrix data)
        {
            this.m_originalMatrix = data;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        /// Returns the original supplied data to be analyzed.
        /// </summary>
        public Matrix Data
        {
            get { return this.m_originalMatrix; }
        }

        public Vector Scores
        {
            get { return this.m_scores;  }
        }

        public Matrix FeatureVector
        {
            get { return this.m_featureVector; }
        }

        public Vector EigenValues
        {
            get { return this.m_eigenValues; }
        }

        public Matrix EigenVectors
        {
            get { return this.m_eigenVectors; }
        }

        /// <summary>
        /// The contribution is defined as:
        /// Σi=from..to eigenvalue[i] / Σi=1..numberOfEigenvalues eigenvalue[i]
        /// </summary>
        public Vector FractionVariance
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        /// <summary>
        /// Computes the Principal Component Analysis algorithm
        /// </summary>
        /// <param name="type">The type of analysis to be run</param>
        public void Compute(AnalysisType type)
        {
            SampleMatrix matrix = (SampleMatrix)this.m_originalMatrix.Clone();


            // Calculate the covariance or correlation matrix from the set
            Matrix symmetricMatrix;
            if (type == AnalysisType.Covariance)
            {   // Calculate its covariance matrix
                symmetricMatrix = matrix.GenerateCovarianceMatrix();
            }
            else
            {   // Calculate its correlation matrix
                symmetricMatrix = matrix.GenerateCorrelationMatrix();
            }

            
            // Calculate the eigen values and eigen vectors of the new symmetric matrix
            new EigenValueDecomposition(symmetricMatrix)
                .Decompose(out m_eigenValues, out m_eigenVectors);
            


           // Sort the columns of eigenvector matrix in descending order of decreasing values
          /*
            for (int i = 0; i < this.m_eigenValues.Length; i++)
            {
                for (int j = i; j < this.m_eigenValues.Length-1; j++)
                {
                    if (this.m_eigenValues[j] > this.m_eigenValues[j+1])
                    {
                        this.m_eigenValues.SwapRow(j, j + 1);
                        this.m_eigenVectors.SwapColumns(j, j + 1);
                    }
                }
            }
          */ 


            // Find the Z-Scores

        }

        #endregion


        //---------------------------------------------


        #region Private Methods
        #endregion


        //---------------------------------------------

    }
}
