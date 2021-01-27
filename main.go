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

//export GenerateIssuerNonceB64
func GenerateIssuerNonceB64() *C.char {
	issuerNonceB64 := "Do the twist and shake"
	return C.CString(issuerNonceB64)
}

//export Issue
func Issue(issuerPkXml, issuerSkXml, issuerNonceB64, commitmentsJson *C.char) *C.char {
	fmt.Println(issuerPkXml)
	fmt.Println(issuerSkXml)
	fmt.Println(issuerNonceB64)
	fmt.Println(commitmentsJson)
	return C.CString("This darkness, it's smothering me")
}
