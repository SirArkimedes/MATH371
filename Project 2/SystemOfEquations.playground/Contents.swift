//: Playground - noun: a place where people can play

struct Function {
    var a: Double!
    var b: Double!
    var c: Double!
}

struct SystemOfEquations {
    static func solve(f1: Function, f2: Function) -> (Double, Double)? {
        var x: Double!
        var y: Double!

        if f1.a * f2.b == f2.a * f1.b {
            return nil
        } else {
            y = (f1.a * f2.c - f2.a * f1.c) / (f1.a * f2.b - f2.a * f1.b)
            x = (f1.c - f1.b * y) / f1.a

            if f1.a == 0.0 {
                x = 0.0
            }

            return (x, y)
        }
    }
}

let f1 = Function(a: 2, b: 5, c: 8)
let f2 = Function(a: 5, b: 10, c: 25)

let values = SystemOfEquations.solve(f1: f1, f2: f2)
if let values = values {
    print(values.0)
    print(values.1)
} else {
    print("No solution!")
}

// ax + by = c
// dx + ey = f
// x = (c - by) / a
// x = (f - ey) / d
// (c-by)/a = (f-ey)/d
// d(c-by) = a(f-ey)
// dc - dby = af - aey
// aey - dby = af - dc
// y(ae - db) = af - dc
// y = (af - dc) / (ae - db)
