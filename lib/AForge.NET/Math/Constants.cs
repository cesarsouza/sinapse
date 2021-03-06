/* 
   Based on work from
   Copyright (C) 1984 Stephen L. Moshier (original C version - Cephes Math Library)
   Copyright (C) 1996 Leigh Brookshaw	(Java version)
   Copyright (C) 2005 Miroslav Stampar	(C# version)
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AForge.Mathematics
{
    public static class Constants
    {

        /// <summary>
        /// Boltzman constant [J/K]
        /// </summary>
        public const double Boltzman = 1.380650324e-23;

        /// <summary>
        /// Elementary charge [C] 
        /// </summary>
        public const double ElementaryCharge = 4.8032e-10;

        /// <summary>
        ///  Charge on the electron [C]
        /// </summary>
        public const double ElectronCharge = -1.60217646263e-19;

        /// <summary>
        /// Electron mass [kg] 
        /// </summary>
        public const double ElectronMass = 9.1093818872e-31;

        /// <summary>
        ///   Proton mass [kg] 
        /// </summary>
        public const double ProtonMass = 1.6726215813e-27;

        /// <summary>
        ///   Neutron mass [kg]
        /// </summary>
        public const double NeutronMass = 1.6749271613e-27;

        /// <summary>
        ///   Gravitational constant [dyne-cm^2 g^-2]
        /// </summary>
        public const double Gravitation = 6.6720e-08;

        /// <summary>
        ///   Planck constant [J s] 
        /// </summary>
        public const double Planck = 6.6260687652e-34;

        /// <summary>
        ///   Reduced Planck constant [J s]
        /// </summary>
        public const double PlanckReduced = Planck / (2*Math.PI);

        /// <summary>
        ///   Speed of light in vacuum [m s^-1] 
        /// </summary>
        public const double LightSpeed = 2.99792458e8;

        /// <summary>
        /// Stefan-Boltzman constant [J/cm^2 - sec - deg^4]
        /// </summary>
        public const double StefanBoltzman = 5.6703e-5;

        /// <summary>
        ///   Avogadro number [mol]
        /// </summary>
        public const double Avogadro = 6.0221419947e23;

        /// <summary>
        ///   Universal molar gas constant [K^-1 mol^-1]
        /// </summary>
        public const double Gas = 8.31447215;

        /// <summary>
        ///   Gravitational acceleration at the Earths surface [m s^-2]
        /// </summary>
        public const double GravitationalAcceleration = 9.8067;

        /// <summary>
        ///   Solar mass [g] 
        /// </summary>
        public const double SolarMass = 1.99e33;

        /// <summary>
        ///   Solar radius [cm]
        /// </summary>
        public const double SolarRadius = 6.96e10;

        /// <summary>
        ///   Solar luminosity [J s^-1]
        /// </summary>
        public const double SolarLuminosity = 3.90e33;

        /// <summary>
        ///   Solar Flux [ J cm^-2 -s ]
        /// </summary>
        public const double SolarFlux = 6.41e10;

        /// <summary>
        ///   Astronomical unit (radius of the Earth's orbit) [cm]
        /// </summary>
        public const double AstronomicalUnit = 1.50e13;

        /// <summary>
        ///   Magnetic permeability of free space [ 4π10-7 H m-1 (N A-2)]
        /// </summary>
        public const double MagneticPermeability = Math.PI*4.0e-7; 

        /// <summary>
        ///   Electrical permittivity of free space [F m-1]
        /// </summary>
        public const double ElecticalPermittitivity = 8.854187817e-12;

        /// <summary>
        ///   Faraday constant [C mol-1]
        /// </summary>
        public const double Faraday = 9.6485341539e4;

        /// <summary>
        ///   Absolute zero [Celsius]
        /// </summary>
        public const double AbsoluteZero = -273.15;

        /// <summary>
        ///   Euler's constant (gamma)  
        /// </summary>
        public const double EulersGamma = 0.5772156649015627;
         
    }
}
