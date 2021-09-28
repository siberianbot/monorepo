package main

import (
	"fmt"
	"os"
	"strconv"
)

func factorial(i int) int {
	if i <= 1 {
		return 1
	}

	return i * factorial(i-1)
}

func main() {
	if len(os.Args) == 1 {
		fmt.Println("no arguments")
		return
	}

	i, err := strconv.Atoi(os.Args[1])

	if err != nil {
		fmt.Printf("failure: %v\r\n", err)
		return
	}

	fmt.Printf("factorial of %d = %d", i, factorial(i))
}
