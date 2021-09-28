package types

import (
	"errors"
	"os/exec"
)

type Task interface {
	Name() string
	CreateCommand() (*exec.Cmd, error)
}

type TaskImpl struct {
	TaskName   string   `json:"name"`
	Command    string   `json:"cmd"`
	Args       []string `json:"args"`
	WorkingDir string   `json:"workdir"`
	Next       []string `json:"next"`
}

func (task TaskImpl) Name() string {
	return task.TaskName
}

func (task TaskImpl) CreateCommand() (*exec.Cmd, error) {
	if len(task.Command) == 0 {
		return nil, errors.New("no command (cmd) is provided in task")
	}

	cmd := exec.Command(task.Command, task.Args...)

	if len(task.WorkingDir) != 0 {
		cmd.Dir = task.WorkingDir
	}

	return cmd, nil
}
