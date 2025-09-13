# Problem: Find the Town Judge

There are n people numbered from 1 to n in a town. There's a rumor that one of these

people is secretly the town judge. A town judge must meet the following conditions:



1\. The judge doesn't trust anyone.

2\. Everyone else in the town (except the town judge) trusts the judge.

3\. There is exactly one person who fulfills both the above conditions.



You are given an integer n and a two-dimensional array, trust, where each entry

trust\[i] = \[ai, bi] indicates that the person labeled a¿ trusts the person labeled bi.

If a trust relationship is not specified in the trust array, it does not exist. Your task is

to determine the label of the town judge, if one can be identified. If no such person

exists, return -1.

## Constraints:



* 1 <n ≤ 1000
* 0 <trust.length ≤ 104
* trust\[i].length == 2
* ai =bi
* 1 <ai, bi ≤n
* All the pairs in trust are unique.
