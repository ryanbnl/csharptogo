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
	issuerNonceB64 := "GenerateIssuerNonceB64 has generated!"
	return C.CString(issuerNonceB64)
}

//export Issue
func Issue(issuerPkXml, issuerSkXml, issuerNonceB64, commitmentsJson string) *C.char {
	fmt.Println(issuerPkXml)
	fmt.Println(issuerSkXml)
	fmt.Println(issuerNonceB64)
	fmt.Println(commitmentsJson)
	return C.CString("Issuer has issued!")
}
