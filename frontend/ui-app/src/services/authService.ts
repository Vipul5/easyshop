import axios from "axios";

const AUTH_URL = `${import.meta.env.VITE_AUTH_URL}/auth`;

export const login = async (email: string, password: string) => {
  const response = await axios.post(`${AUTH_URL}/login`, {
    email,
    password,
  });

  return response.data;
};

export const register = async (email: string, password: string) => {
  const response = await axios.post(`${AUTH_URL}/register`, {
    email,
    password,
  });

  return response.data;
};