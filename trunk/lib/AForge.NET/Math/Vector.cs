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

namespace AForge.Math
{

    /// <summary>
    /// A spatial vector, or simply vector, is a geometric
    /// object which has both a magnitude and a direction.
    /// </summary>
    public class Vector
    {

        private double[] m_data;
        private int m_length; // cache vector size for performance


        //---------------------------------------------


        #region Constructor
        private Vector()
        {
        }

        public Vector(int size)
        {
            this.m_data = new double[size];
            this.m_length = size;
        }

        public Vector(params double[] vector)
        {
            this.m_data = (double[])vector.Clone();
            this.m_length = vector.GetLength(0);
        }

        public Vector(Vector vector)
        {
            this.m_data = vector.m_data;
            this.m_length = vector.m_length;
        }
        #endregion


        //---------------------------------------------


        #region Properties
        public double this[int index]
        {
            get { return this.m_data[index]; }
            set { this.m_data[index] = value; }
        }

        public double Norm
        {
            get
            {
                double sum = 0.0;
                for (int i = 0; i < this.m_length; i++)
                {
                    sum += System.Math.Pow(this.m_data[i], 2);
                }
                return System.Math.Sqrt(sum);
            }
        }

        public double Sum
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < this.m_length; i++)
                {
                    sum += this.m_data[i];
                }
                return sum;
            }
        }

        public int Length
        {
            get { return this.m_length; }
        }
        #endregion


        //---------------------------------------------


        #region Public Methods
        public void IsOrthogonal(Vector vector)
        {
            throw new NotImplementedException();
        }

        public void Swap(int i, int j)
        {
            double aux = this[i];
            this[i] = this[j];
            this[j] = aux;
        }

        public Vector Clone()
        {
            return new Vector(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.m_length; i++)
            {
                sb.Append( this.m_data[i]);

                if (i < this.m_length - 1)
                    sb.Append( "\t");
            }
            return sb.ToString();
        }
        #endregion


        //---------------------------------------------



        #region Operators
        /// <summary>Determines weather two instances are equal.</summary>
        public override bool Equals(object obj)
        {
            return Equals(this, (Vector)obj);
        }

        /// <summary>Determines weather two instances are equal.</summary>
        public static bool Equals(Vector left, Vector right)
        {
            if (((object)left) == ((object)right))
            {
                return true;
            }

            if ((((object)left) == null) || (((object)right) == null))
            {
                return false;
            }

            if (!DimensionEquals(left, right))
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                    if (left[i] != right[i])
                    {
                        return false;
                }
            }

            return true;
        }

        /// <summary>Determines weather two instances have dimension equality.</summary>
        public bool DimensionEquals(Vector value)
        {
            return DimensionEquals(this, value);
        }

        /// <summary>Determines weather two instances have dimension equality.</summary>
        public static bool DimensionEquals(Vector left, Vector right)
        {
            return (left.m_length == right.m_length);
        }

        /// <summary>Unary minus.</summary>
        public static Vector Negate(Vector value)
        {
            return Multiply(value, -1.0);
        }

		/// <summary>Unary minus.</summary>
        public static Vector operator -(Vector value)
        {
            return Negate(value);
        }

		/// <summary>Vector equality.</summary>
        public static bool operator==(Vector left, Vector right)
		{
			return Equals(left, right);
		}

		/// <summary>Vector inequality.</summary>
        public static bool operator!=(Vector left, Vector right)
		{
			return !Equals(left, right);
		}

		/// <summary>Vector addition.</summary>
        public static Vector Add(Vector left, Vector right)
		{
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}

			if (right == null)
			{
				throw new ArgumentNullException("right");
			}

			if (!DimensionEquals(left, right))
			{
				throw new ArgumentException("Vector dimension do not match.");
			}

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r.m_data[i] = left.m_data[i] + right.m_data[i];
            }
			return r;
		}

		/// <summary>Matrix addition.</summary>
        public static Vector operator +(Vector left, Vector right)
		{
			return Add(left, right);
		}

		/// <summary>Matrix subtraction.</summary>
        public static Vector Subtract(Vector left, Vector right)
		{
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (!DimensionEquals(left, right))
            {
                throw new ArgumentException("Vector dimension do not match.");
            }

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r.m_data[i] = left.m_data[i] - right.m_data[i];
            }
            return r;
		}

		/// <summary>Matrix subtraction.</summary>
        public static Vector operator-(Vector left, Vector right)
		{
			return Subtract(left, right);
		}

		/// <summary>Matrix-scalar multiplication.</summary>
        public static Vector Multiply(Vector left, double right)
		{
			if (left == null)
			{
				throw new ArgumentNullException("left");
			}

            Vector r = new Vector(left.m_length);
            for (int i = 0; i < left.m_length; i++)
            {
                r[i] = left.m_data[i] * right;
            }
			return r;
		}

		/// <summary>Matrix-scalar multiplication.</summary>
        public static Vector operator *(Vector left, double right)
		{
			return Multiply(left, right);
		}

        /// <summary>Matrix-scalar multiplication.</summary>
        public static Vector operator *(double left, Vector right)
        {
            return Multiply(right,left);
        }

        public static Vector Divide(Vector left, double right)
        {
            return Multiply(left, 1.0 / right);
        }

        public static Vector operator /(Vector left, double right)
        {
            return Divide(left, right);
        }

        public static Vector operator /(double left, Vector right)
        {
            return Divide(right, left);
        }

        /// <summary>Returns the vector in a double[] form.</summary>
        public static explicit operator double[](Vector vector)
        {
            return (double[])vector.m_data.Clone();
        }

        public static explicit operator Vector(double[] vector)
        {
            Vector r = new Vector();
            r.m_data = vector;
            r.m_length = vector.Length;
            return r;
        }
        #endregion


        //---------------------------------------------


        #region Static Methods
        public static Vector Pow(Vector vector, double power)
        {
            Vector r = vector.Clone();
            for (int i = 0; i < r.m_data.Length; i++)
            {
                r.m_data[i] = System.Math.Pow(r.m_data[i], power);
            }
            return r;
        }

        public static void Normalize(Vector vector)
        {
            double norm = vector.Norm;

            for (int i = 0; i < vector.m_length; i++)
            {
                vector[i] = vector[i] / norm;
            }
         }
        #endregion

    }
}