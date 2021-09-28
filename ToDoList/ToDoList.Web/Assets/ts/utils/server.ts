export interface IServer {
    sendAsync<TRequestModel, TResponseModel>(method: string, url: string, request: TRequestModel): Promise<TResponseModel>;

    getAsync<TResponseModel>(url: string): Promise<TResponseModel>;

    postAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel>;

    putAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel>;

    deleteAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel>;
}

class Server implements IServer {
    public async sendAsync<TRequestModel, TResponseModel>(method: string, url: string, requestModel: TRequestModel): Promise<TResponseModel> {

        const request: RequestInit = {
            method: method,
            mode: 'same-origin'
        }

        if (method !== 'GET') {
            request.headers['Content-Type'] = 'application/json';
            request.body = JSON.stringify(requestModel);
        }

        const response = await fetch(url, request);

        return await response.json();
    }

    public getAsync<TResponseModel>(url: string): Promise<TResponseModel> {
        return this.sendAsync('GET', url, null);
    }

    public postAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel> {
        return this.sendAsync('POST', url, request);
    }

    public putAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel> {
        return this.sendAsync('PUT', url, request);
    }

    public deleteAsync<TRequestModel, TResponseModel>(url: string, request: TRequestModel): Promise<TResponseModel> {
        return this.sendAsync('DELETE', url, request);
    }
}

const server: IServer = new Server();

export default server;