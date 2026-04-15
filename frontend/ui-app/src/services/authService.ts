import axios from "axios";

const AUTH_URL = `${import.meta.env.VITE_AUTH_URL}/auth`;

export const login = async (userName: string, password: string) => {
  const response = await axios.post(`${AUTH_URL}/login`, {
    userName,
    password,
  });

  return response.data;
};

export const register = async (userName: string, password: string) => {
  const response = await axios.post(`${AUTH_URL}/register`, {
    userName,
    password,
  });

  return response.data;
};