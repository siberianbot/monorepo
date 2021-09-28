package executor

import (
	"cooper/internal/cooper/types"
	"fmt"
	"log"
)

func ExecuteTask(scenario types.Scenario, task types.Task) error {
	taskName := task.Name()
	log.Printf("executing task %s\n", taskName)

	cmd, err := task.CreateCommand()

	if err != nil {
		return fmt.Errorf("failed to prepare task %s: %v", taskName, err)
	}

	logWriter := log.Writer()
	cmd.Stdout = logWriter
	cmd.Stderr = logWriter

	err = cmd.Run()
	if err != nil {
		return fmt.Errorf("failed to execute task %s: %v", taskName, err)
	}

	nextTasks, err := scenario.FindNext(task)
	if err != nil {
		return fmt.Errorf("failed to extract next tasks of task %s: %v", taskName, err)
	}

	for _, nextTask := range nextTasks {
		if err := ExecuteTask(scenario, nextTask); err != nil {
			return err
		}
	}

	return nil
}

func ExecuteScenario(scenario types.Scenario) error {
	task, err := scenario.InitialTask()

	if err != nil {
		return err
	}

	err = ExecuteTask(scenario, task)
	if err != nil {
		return fmt.Errorf("failed to execute scenario: %v", err)
	}

	return nil
}
