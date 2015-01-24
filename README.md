PDDL#
=====

## Planning Domain Definition Language Parser 

PDDL# is a parser for the [PDDL](http://en.wikipedia.org/wiki/Planning_Domain_Definition_Language) DSL written in C#.

### Language level and completeness

The library is currently targeted at PDDL 1.2. The following concepts are *not* yet implemented:

* Requirements
	* `:action-expansions`
	* `:conditional-effects`
	* `:domain-axioms`
	* `:disjunctive-preconditions`
	* `:dag-expansions`
	* `:existential-preconditions`
	* `:foreach-expansions`
	* `:equality`
	* `:expression-evaluation`
	* `:quantified-preconditions`
	* `:subgoals-through-axioms`
	* `:universal-preconditions`
* Problem
	* Situations (`:situation`)
	* Lengths (`:length`)

The following definition types are not implemented:

* `addendum`

Partial implementations exist for:

* `:conditional-effects`
	* The `:vars` action keyword is recognized.
* `:existential-preconditions`
	* The `:vars` action keyword is recognized. 
* `:fluents`
	* Fluents are recognized in variable definitions, however no further handling is implemented.
* `:open-world`
	* The requirement is recognized.
* `:true-negation`
	* The requirement is recognized.

Fully understood concepts are:

* `:domain-axioms`
* `:strips`
* `:typing`
* `:safety-constraints`

### License

The project is licensed under the [EUPL v.1.1](https://joinup.ec.europa.eu/software/page/eupl/licence-eupl), a copy of which can be found in [LICENSE.md](LICENSE.md).