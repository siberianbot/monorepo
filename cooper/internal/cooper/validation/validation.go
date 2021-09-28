package validation

import (
	"cooper/internal/cooper/types"
	"cooper/internal/cooper/utils"
	"errors"
)

func ValidateTask(task types.Task) error {
	taskImpl, isImplementation := task.(types.TaskImpl)

	if !isImplementation {
		panic("ValidateTask(Task): is not TaskImpl")
	}

	if utils.IsEmpty(taskImpl.TaskName) {
		return errors.New("error in task: task name (\"name\") is required")
	}

	if utils.IsEmpty(taskImpl.Command) {
		return errors.New("error in task: command (\"cmd\") is required")
	}

	return nil
}

func ValidateScenario(scenario types.Scenario) error {
	scenarioImpl, isImplementation := scenario.(types.ScenarioImpl)

	if !isImplementation {
		panic("ValidateScenario(Scenario): is not ScenarioImpl")
	}

	if utils.IsEmpty(scenarioImpl.InitialTaskName) {
		return errors.New("error in scenario: initial task name (\"initial\") is not provided")
	}

	for _, task := range scenarioImpl.Tasks {
		if err := ValidateTask(task); err != nil {
			return err
		}
	}

	return nil
}
