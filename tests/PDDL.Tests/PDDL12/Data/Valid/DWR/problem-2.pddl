;; a problem with 8 locations and 3 robots
;; Goals:
;; - move all containers from la to lf (unload ship la into lf)
;; - move all containters from lb to lc (unload ship lb into lc)
;; - move all containers from le to la (reload ship la with le)
;; - move all containers form lb to ld (reload ship lb with ld)

(define (problem dwrpb8)
  (:domain dock-worker-robot)
  (:objects
   ra rb rc  - robot
   la lb lc ld le lf li lj - location
   ga gb gc gd ge gf - crane
   pa qa pb qb pc qc pd qd pe qe pf qf - pile
   a b c d e f g h i j k l m n o p q r s t u v w x  pallet - container)


  (:init
   (adjacent la li)
   (adjacent li la)
   (adjacent lb lj)
   (adjacent lj lb)
   (adjacent lc lj)
   (adjacent lj lc)
   (adjacent ld lj)
   (adjacent lj ld)
   (adjacent le li)
   (adjacent li le)
   (adjacent lf li)
   (adjacent li lf)
   (adjacent li lj)
   (adjacent lj li)

   (attached pa la)
   (attached qa la)

   (attached pb lb)
   (attached qb lb)

   (attached pc lc)
   (attached qc lc)

   (attached pd ld)
   (attached qd ld)

   (attached pe le)
   (attached qe le)

   (attached pf lf)
   (attached qf lf)



   (belong ga la)
   (belong gb lb)
   (belong gc lc)
   (belong gd ld)
   (belong ge le)
   (belong gf lf)

   (in a pa)
   (in b pa)
   (in c pa)
   (in d qa)
   (in e qa)
   (in f qa)

   (in g pb)
   (in h pb)
   (in i pb)
   (in j qb)
   (in k qb)
   (in l qb)

   (in m pe)
   (in n pe)
   (in o pe)
   (in p qe)
   (in q qe)
   (in r qe)

   (in s pd)
   (in t pd)
   (in u pd)
   (in v qd)
   (in w qd)
   (in x qd)

   (on a pallet)
   (on b a)
   (on c b)
   (top c pa)

   (on d pallet)
   (on e d)
   (on f e)
   (top f qa)

   (on g pallet)
   (on h g)
   (on i h)
   (top i pb)

   (on j pallet)
   (on k j)
   (on l k)
   (top l qb)


   (on m pallet)
   (on n m)
   (on o n)
   (top o pe)

   (on p pallet)
   (on q p)
   (on r q)
   (top r qe)

   (on s pallet)
   (on t s)
   (on u t)
   (top u pd)

   (on v pallet)
   (on w v)
   (on x w)
   (top x qd)

   (top pallet pc)
   (top pallet qc)
   (top pallet pf)
   (top pallet qf)


   (at ra la)
   (unloaded ra)
   (occupied la)

   (at rb lb)
   (unloaded rb)
   (occupied lb)

   (at rc lc)
   (unloaded rc)
   (occupied lc)


   (empty ga)
   (empty gb)
   (empty gc)
   (empty gd)
   (empty ge)
   (empty gf))

  (:goal
   (and (in a pf)
	(in b pf)
	(in c pf)
	(in d qf)
	(in e qf)
	(in f qf)
	(in g pc)
	(in h pc)
	(in i pc)
	(in j qc)
	(in k qc)
	(in l qc)

	(in m pa)
	(in n pa)
	(in o pa)
	(in p qa)
	(in q qa)
	(in r qa)
	(in s pb)
	(in t pb)
	(in u pb)
	(in v qb)
	(in w qb)
	(in x qb))))
