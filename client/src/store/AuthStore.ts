import { PUBLIC_API_URL } from '$env/static/public';
import { writable } from 'svelte/store';

export interface User {
  id?: string;
  userName?: string;
}

const createAuthStore = () => {
  const { subscribe, update } = writable<User>({});

  const registerUser = async (userName: string, password: string) => {
    try{
      const result = await fetch(`${PUBLIC_API_URL}/api/Auth/register`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({userName, password})
      });
      const response = await result.json();

      if(!response.succeeded) {
        throw response.errors;
      }

      update(() => {return {userName}});
    } catch(err) {
      console.error(err);
    }
  };

  return { subscribe, registerUser }
}

export const AuthStore = createAuthStore();