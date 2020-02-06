# Zxcvbn

This is a port of [Zxcvbn](https://github.com/dropbox/zxcvbn) in C#

## Usage

```csharp
using Devolutions.Zxcvbn;

foreach (var password in passwords)
{
    ZxcvbnResult result = Zxcvbn.Evaluate(password);

    int score = result.Score; // Score from 0 to 4
}
```