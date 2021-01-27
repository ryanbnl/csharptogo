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
//export HelloGalaxy
func HelloGalaxy() *C.char {
	msg := "Hello galaxy"
	fmt.Println(msg)
	return C.CString(msg)
}
