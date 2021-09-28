import * as React from 'react';

const WorkItemContext = React.createContext<number>(undefined);

export default WorkItemContext;

export function useWorkItem() {
    return React.useContext(WorkItemContext);
}