import { PUBLIC_API_URL } from '$env/static/public';

import type { User } from '@src/store/AuthStore';

import type { StoreUpdater } from '../types';

const registerUser = async (userName: string, password: string, update: StoreUpdater<User>) => {
	try {
		const result = await fetch(`${PUBLIC_API_URL}/api/Auth/register`, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({ userName, password })
		});
		const response = await result.json();

		if (!response.succeeded) {
			throw response.errors;
		}

		update(() => {
			return { userName };
		});

    return {type: 'success'}
	} catch (err) {
    return {type: 'error', message: JSON.stringify(err)};
	}
};

export default registerUser;
