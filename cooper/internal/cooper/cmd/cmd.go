package cmd

import (
	"cooper/internal/cooper/executor"
	"cooper/internal/cooper/parsing"
	"cooper/internal/cooper/utils"
	"cooper/internal/cooper/validation"
	"flag"
	"fmt"
	"log"
	"os"
)

var (
	skipValidation bool
)

func InitFlags() {
	flag.BoolVar(&skipValidation, "skip-validation", false, "skips scenario file validation")

	flag.Parse()
}

func PrintUsage() {
	fmt.Println("usage: cooper [flags] -- <path to cooper scenario>")
	flag.PrintDefaults()
}

func Run() {
	log.Println("cooper")

	InitFlags()

	scenarioFile := flag.Arg(0)

	if utils.IsEmpty(scenarioFile) {
		log.Println("nothing to build")
		PrintUsage()

		os.Exit(0)
	}

	scenario, err := parsing.OpenScenario(scenarioFile)
	if err != nil {
		log.Fatal(err)
	}

	if !skipValidation {
		err := validation.ValidateScenario(scenario)
		if err != nil {
			log.Fatal(err)
		}
	}

	err = executor.ExecuteScenario(scenario)
	if err != nil {
		log.Fatal(err)
	}

	log.Println("scenario finished")
}
