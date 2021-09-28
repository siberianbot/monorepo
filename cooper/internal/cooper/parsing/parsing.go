package parsing

import (
	"cooper/internal/cooper/types"
	"encoding/json"
	"io/ioutil"
	"os"
)

func ParseScenario(data []byte) (types.Scenario, error) {
	var scenario types.ScenarioImpl

	err := json.Unmarshal(data, &scenario)

	if err != nil {
		return nil, err
	}

	return scenario, nil
}

func OpenScenario(name string) (types.Scenario, error) {
	file, err := os.Open(name)

	if err != nil {
		return nil, err
	}

	data, err := ioutil.ReadAll(file)
	if err != nil {
		return nil, err
	}

	_ = file.Close()

	scenario, err := ParseScenario(data)

	if err != nil {
		return nil, err
	}

	return scenario, nil
}
