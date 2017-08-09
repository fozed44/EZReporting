

export interface connectionString {
    pkID: number;
    Name: string;
    Value: string;
}

export class connectionStringEndpoints {
    public load:   string;
    public create: string;
    public delete: string;
    public update: string;
}

export interface serverResultBase {
    success: boolean;
}

export interface connectionStringsServerResult extends serverResultBase {
    connectionStrings: connectionString[];
}
