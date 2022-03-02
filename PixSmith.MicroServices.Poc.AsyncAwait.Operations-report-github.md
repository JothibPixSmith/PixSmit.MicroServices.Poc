``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1526 (21H1/May2021Update)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                 Method |    Mean |    Error |   StdDev | Allocated |
|----------------------- |--------:|---------:|---------:|----------:|
| ProcessOperationsAsync | 3.200 s | 0.0211 s | 0.0165 s |    142 KB |
|  ProcessOperationsSync | 3.210 s | 0.0159 s | 0.0141 s |    177 KB |
