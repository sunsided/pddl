(define (domain types-only)
 (:types
  location      ; there are several connected locations in the harbor
  pile             ; is attached to a location
                     ; it holds a pallet and a stack of containers
  robot          ; holds at most 1 container, only 1 robot per location
  crane          ; belongs to a location to pickup containers
  container))