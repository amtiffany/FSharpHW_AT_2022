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

[<EntryPoint>]
let randfn argument =
    printfn "%A" var1
    printfn "%A" var2

    printfn "hello"
    GreetFn "Hello!"
    0