# AMRIE
## Antimicrobial Resistance Test Interpretation Engine

This software was created by the [WHONET](https://whonet.org) development team to facilitate
the interpretation of antibiotic measurements according to the published guidelines.
For more information about the guidelines, please visit their websites: [CLSI](https://clsi.org/), [EUCAST](https://www.eucast.org/), [SFM](https://www.sfm-microbiologie.org/)

You can install this software on Windows using the command `winget install WHONET.AMRIE` or by downloading the latest release from GitHub.

The system can be integrated with your project via the Interpretation Engine library, or it
can be used directly with either the command line interface or interactive interface projects.

The library code is written in .NET 8 with no additional package dependencies. It can be directly integrated with other projects on any platform which supports .NET 8.

The interactive system provides access to each interpretation related function from a graphical user interface (Windows only pending a redesign in a cross-platform UI technology).
You may use it to generate the interpretations for an entire data file, or explore ad hoc interpretations and view filtered resources.
For other groups who already have existing software, but wish to incorporate the interpretation engine, the interface project
serves as a working template for how to exercise the major features.

The command line interface is another option which can be used to generate interpretations without requiring knowledge or integration with our library.
Instead, the command line application can be called as needed (from another application, from a batch script, etc.). It may be possible to build the command line
interface for platforms other than Windows with minimal changes.

The breakpoints and other tables will be kept up-to-date over time (Interpretaion Engine\Resources),
and are useful in their own right, even if the software implementation of the engine don't fit your needs.
For example, there are several groups who only utilize specific tables we have made available.

To process a complete data file using the interface or command line application, the input file must use WHONET naming conventions for the 
data columns, measurements, organism codes, etc. The WHONET codes for antibiotics and organisms are defined in the Interpretation Engine\Resources\ folder.
Sample data and configuration files are also provided with the installation package.

We also provide SQL queries which can demonstrate certain aspects of the system, but which are
not used directly by the code here. We have chosen to implement these functions as pure C# code
to assist others if they choose to make their own implementations, and also to eliminate any
dependence on a certain database technology.

The system has automatic breakpoint caching built in (subsequent requests for a given organism and antibiotic are extremely fast),
and offers a way to "preheat" the breakpoint cache to maximize interpretation performance if additional information about the input data set is provided.
