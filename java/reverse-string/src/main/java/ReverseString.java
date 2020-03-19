class ReverseString {

    String reverse(String inputString) {
        
        var chars = inputString.toCharArray();

        StringBuilder builder = new StringBuilder();
        for (int x = chars.length - 1; x >= 0; x--) {
            builder.append(chars[x]);
        }

        return builder.toString();
    }
  
}