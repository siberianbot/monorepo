import * as React from 'react';
import {WorkItemListItem} from "./WorkItemListItem";
import {useQuery} from "react-query";
import {getWorkItems} from "../../services/workitem/get-work-items";
import {Spinner} from "../common/Spinner";

export interface IWorkItemListProps {
    parentWorkItemId?: number;
}

export function WorkItemList(props: IWorkItemListProps) {
    // TODO: use nameof(getWorkItems)
    const getWorkItemsQuery = useQuery(`getWorkItems/${props.parentWorkItemId || ''}`, () => getWorkItems(props.parentWorkItemId));

    if (getWorkItemsQuery.isLoading) {
        return <Spinner/>
    }

    const items = getWorkItemsQuery.data.map(item => <WorkItemListItem
        key={item.id.toString()}
        id={item.id}
        title={item.title}
        type={item.type}
    />);

    return <ol className="list-group list-group-flush">{items}</ol>
}