# cmangos-sharp

Work-in-progress C# port of cMaNGOS. The idea is to leverage the vast
.NET ecosystem of deployment and data frameworks and still remain 100%
compatible with cMaNGOS execution and database schema. It should be a
drop-in substitution (but not replacement!)

`cmangos-sharp` is first and foremost an educational project.

### Prerequisites

- Runtime
  - .NET Core 6 runtime
  - An existing, already configured cMaNGOS MySQL database
- Development
  - All runtime prerequisites above, plus:
  - .NET Core 6 SDK (which includes the runtime)
  - A suitable C# IDE such as Visual Studio, VS Code or JetBrains Rider
  - NuGet to pull dependencies (included in the aforementioned IDEs)

### Beginning Development

- Open your IDE
- Pull NuGet packages
- Copy each `*.conf.dist` file to `*.conf` and customize your configurations
  - You may use your existing cMaNGOS installation `.conf` files 

### Running the Server

- Build the project
  - All executable files should be available at `./bin` after build
- Concurrently run `MangosSharp.Server.Realm` and `MangosSharp.Server.World`

### Project Layout

These things map directly with cMaNGOS:
- `mangosd` -> `MangosSharp.Server.World`
- `realmd` -> `MangosSharp.Server.Realm`

These things differ:
- `MangosSharp.Tool.ExtractDbc` extracts DBC files.
- `MangosSharp.Tool.ExtractSchema` connects to your MySQL instance and
  spits out source files containing `DbContext` and tables for use with
  Entity Framework.
- `MangosSharp.Server.Instance` will become an instance server. Instance
  servers are to be managed by the world server and will eventually do the
  majority of the world (AI, player interaction, etc) for a given set of
  world and instance maps. This is still in design.

### Project Progress

In order of priority:

- realmd
  - Authentication & SRP6
  - Realm list needs implemented
- mangosd
  - Not started.
- Extraction tools
  - Not a high priority, these work offline and MangosSharp will just use
    their output.

### License

While the original cMaNGOS is licensed under GPLv2, this port is licensed
under GPLv3. Refer either to `LICENSE` or the [online version](https://www.gnu.org/licenses/gpl-3.0.en.html)
of the GPLv3 to read it.

### Contributions

Fork `cmangos-sharp` and make your changes, then submit a pull request via
GitHub. [Visit the Pull Requests page](https://github.com/SaxxonPike/cmangos-sharp/pulls)
to get started.

### Issues

Use the GitHub issue tracker to file a new issue. [Visit the Issues page](https://github.com/SaxxonPike/cmangos-sharp/issues)
to get started. The cMaNGOS team cannot provide support for this port; please
do not bother them with issues resulting from this code.

### Authors

The following contributors are credited for their work toward making cmangos-sharp
its best, in chronological order.

- [Saxxon](https://github.com/saxxonpike)
  - Project lead

_If you would like to be credited for your contributions to the project, include
your name in a change to the bottom of the list in this section in your pull
request._
