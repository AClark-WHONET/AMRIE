# AMRIE
## Antimicrobial Resistance Test Interpretation Engine

This software was created by the [WHONET](https://whonet.org) development team to facilitate
the interpretation of antibiotic measurements according to the published guidelines.
For more information about the guidelines, please visit their websites: [CLSI](https://clsi.org/), [EUCAST](https://www.eucast.org/), [SFM](https://www.sfm-microbiologie.org/)

You can install this software on Windows using the command `winget install WHONET.AMRIE` or by downloading the latest release from GitHub.

There are three different sets of needs that the solution aims to support:
1. Interactive use, 2. Command line use, and 3. Library integration.

The library code is written in .NET 8 with no additional package dependencies. It can be directly integrated with other projects on any platform which supports .NET 8.
The interactive interface and the command line interface exercise the various interpretation features.

The interactive system may be used to generate the interpretations for an entire data file, or explore ad hoc interpretations and view filtered resources.
To process a complete data file using the interface or command line application, the input file must use WHONET naming conventions for the 
data columns, measurements, organism codes, etc. The WHONET codes for antibiotics and organisms are defined in the `Interpretation Engine\Resources\` folder.
Sample data and configuration files are also provided with the installation package.

The command line interface is another option which can be used to generate interpretations without requiring knowledge of or integration with the library.
Instead, the command line application can be called as needed (from another application, from a batch script, etc.). It should be possible to build the command line
interface for platforms other than Windows with minimal changes.

We also provide SQL queries which can demonstrate certain concepts, but which are
not used by the code. These functions are implemented in C# to assist others if
they choose to make their own implementations, and also to eliminate any
dependence on a certain database technology which could restrict cross-platform options.

The system has automatic breakpoint caching built in (subsequent requests for a given organism and antibiotic are extremely fast),
and includes a way to "preheat" the breakpoint cache to maximize interpretation performance if additional information about the input data set can be provided.
