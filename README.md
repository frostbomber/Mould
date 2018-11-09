# Mould
Link tree structure with a list where a foreign key relationship
# Usage
Mould is intended for a situation where there is a hierarchical (tree) structure and a list which have some type of foreign key relationship.
For example, each element in the tree has a value-typed property that matches a property of the same value type (e.g. each element in the tree has a PID and that matches with an ID from element(s) within the list).
With Mould, you can aggregate these matched elements into a list and manage the relationships between them.
# Implementation
To use Mould, a user would first create a Mould, which represents the tree.
Part of this would include the user creating relationships, which implement IRelationship.
Then, you can either take one item and Clone(), /or/ take a whole list and Match() to aggregate. Any items at this stage should implement IMouldable.
The Value of MouldItem and the class which implements IMouldable should be the "foreign key" between the tree and the list (PID and ID in the example).
That's all there is to it! You bring the data, with a bit of formatting, and we do the heavy lifting!

<TODO: Full Example>
