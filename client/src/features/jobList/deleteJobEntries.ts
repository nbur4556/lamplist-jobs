import type { StoreUpdater } from './types';

const deleteJobEntries = async (id: number, update: StoreUpdater) => {
	try {
		await fetch(`http://localhost:5000/api/joblist/${id}`, {
			method: 'DELETE'
		});
		update((state) => state.filter((val, i) => i !== id));
	} catch (err) {
		//TODO: Error Handling
		console.error(err);
	}
};

export default deleteJobEntries;
