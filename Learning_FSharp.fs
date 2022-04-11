//comments are made using "//" (obviously lol)
//F# uses camelCase

//built in functions end in fn

//print
// printfn "hi there!"


//lists
//lists are static 
//all lists contain only one type of element

//"[1;3;4.2]" does NOT work

let lst = [1;2;3]
let lst2 = [1::2::3::[]]
let lstFlt = [1.0;2.3;2.48]
let lstStr = ["word"; "some other phrase"; "yet another phrase"; "2"; "3.4"]


//arrays
//arrays are dynamic, but fixed size
//all arrays contain only one type of element 

let arry = [|1;2;3|]
let arry2 = 
    [|
        1
        2
        3
    |]


//"Entry points" are where coe execution formally starts


//functions are defined by 'let'
//variables are separated by spaces

let GreetFn (phrase:string) = 
    printfn "%s" phrase


let reversefn (oriList) =
    let revArr = [|for i in oriList -> i|]
    let arrLen = revArr.Length - 1
    let arrHalf = revArr.Length/2
    for j = 0 to arrHalf do 
        let a = revArr.[j]
        let b = revArr.[arrLen - j]
        revArr.[j] <- b 
        revArr.[arrLen - j] <- a
        ()
    revArr



    


//for loops are the same as in python, except that they end with "do"
//functions with multiple parameters must have them in parenthesis, and separated with commas

// let trianglefn (character:string, len) = 
//     for length in len do
//         printfn (character * len)


// let multifn (value1:integer, value2:integer) = 
//     let product = value1 * value2
//     product %d //returns at the end


//variables are static by default
//use 'mutable' key word to make dynamic
//use  '<-' to assign new values to dynamic varriables
let var1 = 10

let mutable var2 = 8
var2 <- 9

let var3 = var2

let mutable var4 = 0
var4 <- var2


//string assignments
//%A--> returns anything
//%d--> returns integers
//%s--> returns strings


// reversefn properly named variables
let reversefn2 (oriList:int[]) =
    let revArr = [|for i in oriList -> i|]
    let arrLen = revArr.Length - 1
    let arrHalf = revArr.Length/2
    for j = 0 to arrHalf do 
        let a = revArr.[j]
        let b = revArr.[arrLen - j]
        revArr.[j] <- b 
        revArr.[arrLen - j] <- a
        //printfn "%A: %A" j revArr
    revArr


let sign x = 
    match x with
    | 0 -> 0
    | u when u < 0 -> -1
    | u -> 1

let sign2 x = if x = 0 then 0 else if x < 0 then -1 else 1

let rec fact x =
    if x < 1 then 1
    else x * fact (x - 1)

let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib (n - 1) + fib (n - 2)

// sum of elements of the list
let rec sum list = 
    match list with
    | [] -> 0
    | head :: tail -> head + sum tail

// length of the list
let rec llen list = 
    match list with
    | [] -> 0
    | h :: t -> 1 + llen t

// is the tuple ascending? decending? or neither
let oracle t = 
    match t with
    | (a,b,c) when a > b && b > c -> 1
    | (a,b,c) when a < b && b < c -> -1
    | _-> 0

let oracle2 = function
    | (a,b,c) when a > b && b > c -> 1
    | (a,b,c) when a < b && b < c -> -1
    | _-> 0

let oracle3 (a,b,c) =
    if a < b && b < c then -1
    else if a > b && b > c then 1
    else 0

///
/// Implement and finish the following two functions that merge two sorted arrays
/// and produce a combined sorted array
/// 
// Functional version
let rec mergeRefactored (a:List<int>) (b:List<int>):List<int> =
    let self = mergeRefactored // renaming into a shorter string
    match a, b with
    | [], [] -> []                           // both are empty
    | h::t, [] | [], h::t -> h::t            // one is empty
    | hA::tA, hB::tB ->
        if hA < hB 
        then hA :: (self tA b)
        else hB :: (self a tB)


let rec mergeRefactored2 (a:List<int>) (b:List<int>):List<int> =
    let self = mergeRefactored2 // renaming into a shorter string
    match a, b with
    | [], [] -> []                           // both are empty
    | h::t, [] | [], h::t -> h::t            // one is empty
    | hA::tA, hB::_ when hA < hB -> hA :: (self tA b)
    | _, hB::tB -> hB :: (self a tB)


let rec mergeRefactored3 (a:List<int>) (b:List<int>):List<int> =
    let cat x y z = x :: (mergeRefactored3 y z) // renaming into a shorter string
    match a, b with
    | [], [] -> []                           // both are empty
    | h::t, [] | [], h::t -> h::t            // one is empty
    | hA::tA, hB::_ when hA < hB -> cat hA tA b 
    | _, hB::tB                  -> cat hB a tB



// Iterative version should use loops
let mergeUsingIndexes (a:int[]) (b:int[]):int[] = 
    let combined = a.Length + b.Length
    let result = Array.zeroCreate combined
    // TODO: Implement
    // you will need to maintain two indexes inside the loop of the elements being considered
    // as you select element from each input array you will ned to update indexes
    let mutable XInx = 0
    let mutable YInx = 0
    for i=0 to combined do
        if a[XInx] > b[YInx] || a[XInx] = b[YInx] then do
            result[i] <- a[XInx]
            XInx <- XInx + 1
        else
            if a[XInx] < b[YInx] then do
                result[i] <- b[YInx]
                YInx <- YInx + 1
                
    // let mutable inx = 0
    // let combinedArr = [|for i in 0..combined -> 0|]
    // for i = 0 to a.Length do
    //     for j = 0 to b.Length do
    //         if a[i] > b[j] || a[i] = b[j] then do
    //             combinedArr[inx] <- a[i]
    //             inx <- inx + 1
    //         else 
    //             if a[i] < b[j] then do
    //                 combinedArr[inx] <- b[j]
    //                 inx <- inx + 1 
                
    result



// let mutable inx = 0
// for i in 0..a.Length do
//     for j in 0..b.Length do
//         if a[i] > b[j] or a[i] = b[j] then do
//             combinedArr[inx] <- a[i]
//             inx <- inx + 1
//         else if a[i] < b[j] then do
//             combinedArr[inx] <- b[j]
//             inx <- inx + 1

//type MyType = {| color:string; weight:float;fish:string|}

type MyRecord = { 
    color:string
    weight:float
    mutable animal:string }

let aa = (3,"foo")
let bb = {| fish = "trout"; weight = 3.3; color="green" |}
let cc = {| fish = "trout"; weight = 3.3; color="red" |}

let qq:MyRecord = { color = "black"; weight =2.0; animal="wolf"  } 
let qq2 = { qq with color="white"}
qq2.animal <- "dddd"

let k = bb.fish


let stuff { color = c; weight = w; animal = a } = a

let stuff2 arg = arg.animal


type Direction = N of int | S of int | E of int | W of int

let d = function
| N(i) -> $"North {i}"
| E(i) -> "East"
| _ -> "??"

type WeightUnits = Kg of float*float | Grams of MyRecord | Milligrams of float | Micrograms of float


let mutable ss = Option.Some 23
ss <- Option.None


type MyList = Cons of int * MyList | Nil

let ll = Cons(3, Cons(5, Cons(0,Nil)))


let zip (v1:int, v2:int) = 
    let mutable combArr = Array.zeroCreate 2
    let combArr[0] <- v1
    let combArr[1] <- v2
    combArr 

let zipList (l1:list<int>) (l2:list<int>) = 
    let len = l1.Length + l2.Length 
    let mutable combArr = Array.zeroCreate len
    for i=0 to l1.Length do
        combArr[i] <- l1[i]
    let mutable ind = 0
    for i=l1.Length to len do
        combArr[i] <- l1[ind]
        ind <- ind + 1

let rec count (a:MyList) = 
    match a with
    | Nil -> 0
    | Cons(h, t) -> 1 + count t 

let rec add (a:MyList) =
    match a with 
    | Nil -> 0
    | Cons(h, t) -> h + add t 




[<EntryPoint>]
let randfn argument =
    printfn "%A" var1
    printfn "%A" var2

    printfn "hello"
    GreetFn "Hello!"
    0