import * as React from 'react';
import {AppLayout} from './components/layout/AppLayout';
import {QueryClient, QueryClientProvider} from "react-query";
import WorkItemContext from "./components/workitems/WorkItemContext";

const queryClient = new QueryClient();

export function AppRoot() {
    return (
        <>
            <QueryClientProvider client={queryClient}>
                <WorkItemContext.Provider value={null}>
                    <AppLayout/>
                </WorkItemContext.Provider>
            </QueryClientProvider>
        </>
    );
}