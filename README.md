## Hanging mono executables that involve certain ikvm usage

```
$ mono ikvmc.exe -out:commons-logging.dll -assembly:commons-logging -version:1.1.1.0 -target:library commons-logging-1.1.1.jar 
## warnings about Log4j et al. missing; java.util.logging will be used by default
```

```
$ gmcs -out:Test.exe -target:exe -reference:IKVM.Runtime.dll -reference:IKVM.OpenJDK.Core.dll -reference:commons-logging.dll -main:Test Test.cs 
Test.cs(9,9): warning CS0219: The variable `log' is assigned but its value is never used
Compilation succeeded - 1 warning(s)
```

`Test.cs` as-is will fail to exit; uncommenting the
System.Environment.Exit() call will have no effect.
`^C` is necessary to terminate the process.

```
$ mono Test.exe 
should exit!
^C
```

### Workaround

Compile `Test.exe` from `Test2.cs` instead…

```
$ gmcs -out:Test.exe -target:exe -reference:IKVM.Runtime.dll -reference:IKVM.OpenJDK.Core.dll -reference:commons-logging.dll -main:Test Test2.cs 
Test.cs(9,9): warning CS0219: The variable `log' is assigned but its value is never used
Compilation succeeded - 1 warning(s)
```

The program will exit as requested:

```
$ mono Test.exe 
exiting...
$
```

Of course, it should exit of its own accord, without the `System.exit` call,
but it's almost stranger to me that `System.exit` is effective whereas
`System.Environment.Exit` is entirely ineffective.
