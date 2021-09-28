import * as React from 'react';
import {WorkItemList} from "./WorkItemList";
import {WorkItemType} from "../../services/workitem/get-work-items";

export interface IWorkItemListItemProps {
    id: number;
    title: string;
    type: WorkItemType;
}

export function WorkItemListItem(props: IWorkItemListItemProps) {
    return (
        <li className="list-group-item">
            <div>{props.title}</div>
            <WorkItemList parentWorkItemId={props.id}/>
        </li>
    );
}