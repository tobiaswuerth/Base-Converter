# base-converter

Convert any base to base-ten and visa versa.

## Usage

The library needs to be referenced by the project.
Using it is quite straight forward.

#### Base-10 -> Base-N
```
var input = "657984635468794654687654686484684987445135121111215534"; // base 10
var charset = "0123456789ABCDEF"; // base 16 charset
var output = BaseConverter.ToBase(charset, input); // base 16

>> 6DEA35B676A77A9025BA2A8289C40CEAEA7FD88EE6DAE
```

#### Base-N -> Base-10
```
var input = "6DEA35B676A77A9025BA2A8289C40CEAEA7FD88EE6DAE"; // base 16
var charset = "0123456789ABCDEF"; // base 16 charset
var ouput = BaseConverter.ToDec(charset, input); // base 10

>> 657984635468794654687654686484684987445135121111215534
```

## Parameters

Valid input types for `.ToBase`-Method are:

```
charset: 
    - Char[]
    - String
    
input:
    - Int32
    - String
    - BigInteger
```

Valid input types for `.ToDec`-Method are:

```
charset:
    - Char[]
    - String
input:
    - String
```
