import * as React from 'react';
import {useWorkItem} from "./WorkItemContext";
import {WorkItemDetail} from "./WorkItemDetail";

export function WorkItemContainer() {
    const workItem = useWorkItem();

    return (
        <>
            {!workItem &&
            <div>
                <span>no work item selected</span>
            </div>}
            
            {workItem && <WorkItemDetail workItemId={workItem} />}
        </>
    );
}