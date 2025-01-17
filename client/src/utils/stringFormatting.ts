export const upperCaseWordsInSentence = (sentence: string) => {
	const words = sentence.split(' ');
	return words.reduce((acc, val) => acc + ' ' + val[0].toUpperCase() + val.substring(1), '');
};
