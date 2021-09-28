export interface IUrlHelper {
    createUrl(relativeUrl: string, query?: { [key: string]: any }): string;
}

class UrlHelper implements IUrlHelper {
    private readonly _baseUrl: string;

    constructor() {
        this._baseUrl = document.getElementsByTagName('meta')['baseUrl'].content;
    }

    createUrl(relativeUrl: string, query?: { [key: string]: any }): string {
        const url = new URL(relativeUrl, this._baseUrl);

        if (query) {
            for (const item in query) {
                if (query[item]) {
                    url.searchParams.append(item, query[item]);
                }
            }
        }

        return url.toString();
    }
}

const urlHelper: IUrlHelper = new UrlHelper();

export default urlHelper;