import * as React from 'react';
import {NavBar} from './NavBar';
import {WorkItemList} from "../workitems/WorkItemList";
import {useWorkItem} from "../workitems/WorkItemContext";
import {WorkItemContainer} from "../workitems/WorkItemContainer";

export function AppLayout() {
    const workItem = useWorkItem();

    return (
        <>
            <NavBar/>

            <div className="container-fluid">
                <div className="row">
                    <div className="p-0 col col-xl-3 col-md-4 col-sm-6">
                        <div className="my-2">
                            <button type="button" className="btn btn-link">new task</button>
                            <button type="button" className="btn btn-link">refresh</button>
                        </div>
                        <div className="my-2">
                            <WorkItemList/>
                        </div>
                    </div>
                    <div className="col">
                        <WorkItemContainer />
                    </div>
                </div>
            </div>
        </>
    )
}