# Rig Plugin Samples

Sample projects built with the [Rig](https://rigplugin.com) plugin for Rhino.

- **Excavator** — a comprehensive parametric excavator model that demonstrates a wide range of Rig concepts.
- **Extrusion** — a minimal example showing a single extrusion component.

## Building

These samples reference the Rig plug-in (`Rig.rhp`). You need:

1. Rhino 8.
2. The Rig plug-in installed.

Each project resolves `Rig.rhp` from the standard Rhino plug-in location via the `RigPluginDir`
MSBuild property, which defaults to:

```
%APPDATA%\McNeel\Rhinoceros\packages\8.0\Rig
```

If your Rig plug-in lives elsewhere, override it when building:

```
dotnet build -p:RigPluginDir="C:\path\to\rig"
```

Open `Samples.sln` to build both projects.
