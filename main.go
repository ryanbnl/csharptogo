package main

import "C"
import (
	"fmt"
)

func main() {
}

//export HelloWorld
func HelloWorld() C.int {
	fmt.Println("hello world")
	return 42
}
