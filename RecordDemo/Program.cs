using static RecordDemo.Demo;

//main
var recs = new List<Record1>
{
	new("Stanley", "Kubrick"),
	new("Stanley", "Kubrick"),
	new("Orson", "Welles"),
};

var classes = new List<Class1>
{
	new("Stanley", "Kubrick"),
	new("Stanley", "Kubrick"),
	new("Orson", "Welles"),
};

var (fn, ln) = recs[0];

var newRec = recs[0] with { LastName = "Public" };

var rec2 = new Record2("Berkc", "Tezc");

Console.WriteLine(
	@$"
         Record type:                 / Class type:
ToString: {recs[0]}  - {classes[0]}
Equals  :  {Equals(recs[0], recs[1])} - {Equals(classes[0], classes[1])}
==      :  {recs[0] == recs[1]} - {classes[0] == classes[1]}
!=      :  {recs[0] != recs[2]} - {classes[0] != classes[2]}
Reference Equals:  {ReferenceEquals(recs[0], recs[1])} - {ReferenceEquals(classes[0], classes[1])}      
Hash code 0:  {recs[0].GetHashCode()} - {classes[0].GetHashCode()}      
Hash code 1:  {recs[1].GetHashCode()} - {classes[1].GetHashCode()}      
Hash code 2:  {recs[2].GetHashCode()} - {classes[2].GetHashCode()}      

Deconstruction: {fn + ln}
New Rec from existing record: {newRec}

// extended record
{rec2} = {rec2.FirstName}, {rec2.LastName}
{rec2.Greet()}
{rec2.FullName}
"
);
