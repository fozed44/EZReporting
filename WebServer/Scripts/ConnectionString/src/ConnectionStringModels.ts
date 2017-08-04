

export interface connectionString {
    id: number;
    name: string;
    value: string;
}

export class connectionStringEndpoints {
    public load:   string;
    public add:    string;
    public delete: string;
    public update: string;
}

export interface serverResultBase {
    success: boolean;
}

export interface connectionStringsServerResult extends serverResultBase {
    connectionStrings: connectionString[];
}
