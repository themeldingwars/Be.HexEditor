# Be.HexEditor

This repository mirrors the source code of the [Be.HexEditor](http://sourceforge.net/projects/hexbox/) project created by Bernhard Elbl.

## Changes

_See the [CHANGELOG.txt](CHANGELOG.txt) for the full list of changes._

This repository also includes the following additions:

- Changes made by [Jaroslav Imrich](https://github.com/Pkcs11Admin/Be.HexEditor) for the NuGet package
- The ability to color regions in the hex view with a different background color as can be seen below

![alt text](/Media/preview.png "Preview")

## Usage

```c#
HexView.HighlightedRegions.Add(new HighlightedRegion(0, 12, Color.Purple));
```

## License

This project is licensed under MIT, see the [LICENSE](LICENSE.txt) file for more details
