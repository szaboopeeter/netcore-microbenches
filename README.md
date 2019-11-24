# .Net Core Micro-Benchmark Scenarios

## Motivation
During my everyday life, be that as part of my dayjob, open-source projects, consulting, or simple Stackoverflow question, I tend to run into creative code solutions, where the people with (most of the time) good intentions end up writing something that performs terribly.

While I agree with the arguments against premature optimization and that time spent micro-optimizing code outside of hot-paths can usually be better spent, I don't really consider these cases as micro-optimizing. You could probably provide even better performing alternatives (feel free to do so), I'm mostly trying to show that in some cases even the most intuitive solution will perform better than the one considered "creative" by their authors.

## Table of contents
[1 - Mapping objects (using a JSON serializer)](Microbenches/Scenarios/S001ObjectMapping/S001ObjectMapping.md)