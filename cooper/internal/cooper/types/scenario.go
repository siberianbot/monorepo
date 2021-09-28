package types

import (
	"fmt"
)

type Scenario interface {
	Find(name string) (Task, error)
	FindNext(task Task) ([]Task, error)
	InitialTask() (Task, error)
}

type ScenarioImpl struct {
	Tasks           []TaskImpl `json:"tasks"`
	InitialTaskName string     `json:"initial"`
}

func (scenario ScenarioImpl) Find(name string) (Task, error) {
	for _, task := range scenario.Tasks {
		if task.TaskName == name {
			return task, nil
		}
	}

	return nil, fmt.Errorf("no task with name \"%s\"", name)
}

func (scenario ScenarioImpl) FindNext(task Task) ([]Task, error) {
	taskImpl, isImpl := task.(TaskImpl)

	if !isImpl {
		panic("Scenario.FindNext(Task): provided Task is not TaskImpl")
	}

	count := len(taskImpl.Next)
	if count == 0 {
		return nil, nil
	}

	result := make([]Task, count)
	for i, nextTaskName := range taskImpl.Next {
		nextTask, err := scenario.Find(nextTaskName)

		if err != nil {
			return nil, err
		}

		result[i] = nextTask
	}

	return result, nil
}

func (scenario ScenarioImpl) InitialTask() (Task, error) {
	task, err := scenario.Find(scenario.InitialTaskName)

	if err != nil {
		return nil, fmt.Errorf("no initial task with name \"%s\"", scenario.InitialTaskName)
	}

	return task, nil
}
