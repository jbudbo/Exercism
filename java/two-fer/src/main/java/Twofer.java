class Twofer {
    String twofer(String name) {

        return (name == null || name.isBlank()) ? 
            "One for you, one for me." :
            String.format("One for %s, one for me.", name);

    }
}
