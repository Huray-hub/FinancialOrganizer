import axios, { AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../..";
import {IUser, IUserFormValues} from "../models/user";

axios.defaults.baseURL = "http://localhost:5000/api";

axios.interceptors.request.use(
    (config) => {
        const token = window.localStorage.getItem("jwt");

        if (token) config.headers.Authorization = `Bearer ${token}`;

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

axios.interceptors.response.use(undefined, (error) => {
    if (error.message === "Network Error" && !error.response)
        toast.error("Network Error!");

    const { status, data, config } = error.response;

    if (status === 404) history.push("/notfound");

    if (
        status === 400 &&
        config.method === "get" &&
        data.errors.hasOwnProperty("id")
    )
        history.push("/notfound");

    if (status === 500)
        toast.error("Server error - check the terminal for more info");

    throw error.response;
});

const responseBody = (response: AxiosResponse) => response.data;

const sleep = (ms: number) => (response: AxiosResponse) =>
    new Promise<AxiosResponse>((resolve) =>
        setTimeout(() => resolve(response), ms)
    );

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    del: (url: string) => axios.delete(url)
};

const User = {
    currentUser: (): Promise<IUser> => requests.get("/authentication/currentUser"),
    login: (user: IUserFormValues): Promise<IUser> => requests.post("/authentication/login", user),
    register: (user: IUserFormValues): Promise<IUser> => requests.post("/authentication/register", user)
};

export default {
    User
};