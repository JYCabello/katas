


let (|Fizz|_|) num =
  if num % 3 = 0 then Some "Fizz" else None

let (|Buzz|_|) num =
  if num % 5 = 0 then Some "Buzz" else None

let (|FizzBuzz|_|) num =
  if num % 15 = 0 then Some "FizzBuzz" else None

let fizzBuzz num =
  match num with
  | Fizz f -> f
  | Buzz b -> b
  | FizzBuzz fb -> fb
  | num -> string num



// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
