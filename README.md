# AMRIE
## Antimicrobial Resistance Test Interpretation Engine

This software was created by the [WHONET](https://whonet.org) development team to facilitate
the interpretation of antibiotic measurements according to the various supported guidelines
available for this purpose, and published by those groups ([CLSI](https://clsi.org/), [EUCAST](https://www.eucast.org/), etc.).

You can install this software on Windows using the command `winget install WHONET.AMRIE` or by downloading the latest release from GitHub.
The solution is built using C# and .NET 8 with the intent of building for other platforms in the future.

The system can be integrated with your project via the Interpretation Engine library, or it
can be used directly with either the command line interface or interactive interface projects.

The interactive interface is designed primarily to allow you to exercise the various functions
of the system, but it can also allow you to process an input file into an output file with the
interpretations.

The command-line interface facilitates easy incorporation with a 3rd-party system since the
developer does not need to know how to use the various library functions required to generate interpretations.
The CLI project is very small, so it should serve as a window into how to accomplish the
basic needs for generating interpretations if direct library integration was preferred.

The breakpoints and other tables will be kept up-to-date over time (Interpretaion Engine\Resources),
and are useful in their own right, even if the software implementation of the engine is not for
your purposes. For example, there are several groups who only utilize our tables.
This repository now serves as the official source for these WHONET-related resources.

To process a complete data file using the interface or command line application, the input file must use WHONET naming conventions for the 
data columns, measurements, organism codes, etc. The WHONET codes for antibiotics and organisms are defined in the Interpretation Engine\Resources\ folder.
Sample data and configuration files are also provided with the installation package.

We also provide SQL queries which can demonstrate certain aspects of the system, but which are
not used directly by the code here. We have chosen to implement these functions as pure C# code
to assist others if they choose to make their own implementations, and also to eliminate any
dependence on a certain database technology. Because the application only uses C# with a recent
.NET version combined with plain-text resources, it should be possible to adapt the library code for many platforms.
