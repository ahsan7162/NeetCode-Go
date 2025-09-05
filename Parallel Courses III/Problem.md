# Problem: Parallel Courses III

You are tasked with determining the minimum time required to complete a set of courses, given their prerequisite relationships and individual durations.

There are n courses labeled from 1 to n. The prerequisite relationships between these courses are provided as a 2D integer array relations, where each entry relations[j]=[prevCoursej, nextCoursej] indicates that course prevCoursej must be completed before course nextCoursej. An array, time, is also given, where time[i] specifies the number of months required to complete the course labeled i + 1.

You may begin any course as soon as you have completed all its prerequisites. If all the prerequisites are satisfied, multiple courses may be taken simultaneously. Calculate the minimum months needed to finish all the courses.

## Constraints:


- 1 ≤ n ≤ 5×10^4
- 0 ≤ relations.length ≤ min(n⋅(n−1)/2,5×10^4)
- relations[j].length =2
- 1≤prevCoursej , nextCoursej≤n
- prevCoursej ≠ nextCoursej
- All pairs prevCoursej, nextCoursej are unique.
- time.length = n
- 1 ≤ time[i] ≤ 10^4
- The prerequisite graph is a directed acyclic graph (DAG).