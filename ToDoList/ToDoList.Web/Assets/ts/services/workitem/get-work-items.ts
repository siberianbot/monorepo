import server from "../../utils/server";
import urlHelper from "../../utils/url";

export enum WorkItemType {
    Task = 10,
    Bug = 20
}

export interface IWorkItemSummaryViewModel {
    id: number;
    parentWorkItemId?: number;
    type: WorkItemType;
    title: string;
}

export async function getWorkItems(id?: number, count?: number, offset?: number): Promise<IWorkItemSummaryViewModel[]> {
    const url = urlHelper.createUrl(id ? `api/workitem/${id}` : 'api/workitem', {
        ["count"]: count,
        ["offset"]: offset
    })

    return await server.getAsync<IWorkItemSummaryViewModel[]>(url);
}